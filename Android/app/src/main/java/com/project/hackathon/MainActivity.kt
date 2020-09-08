package com.project.hackathon

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.Html
import android.util.Log
import androidx.recyclerview.widget.LinearLayoutManager
import com.project.hackathon.adapter.RcViewAdapter
import com.project.hackathon.data.Check
import com.project.hackathon.data.Meal
import com.project.hackathon.data.Response
import com.project.hackathon.network.MealClient
import com.project.hackathon.network.MealService
import com.project.hackathon.network.WeatherService
import com.project.hackathon.room.DataBase
import com.project.simplecode.simIntentNoFinish
import kotlinx.android.synthetic.main.activity_main.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import java.text.SimpleDateFormat
import java.util.*
import kotlin.collections.ArrayList

class MainActivity : AppCompatActivity() {

    private val schoolID = "7240393"
    private val officeCode = "D10"

    private var checkList = ArrayList<Check>()
    private val rcViewAdapter = RcViewAdapter()
    var checkDB : DataBase? = null

    lateinit var mealAPI : MealService
    lateinit var weatherAPI : WeatherService
    lateinit var mealRetrofit : Retrofit

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        checkDB = DataBase.getInstance(this)

        rcViewAdapter.setList(checkList)
        checkList.clear()
        checkList.addAll(checkDB?.dao()?.getAll()!!)
        rcViewAdapter.notifyDataSetChanged()
        main_rcView.layoutManager = LinearLayoutManager(this)
        main_rcView.adapter = rcViewAdapter


        mealRetrofit = MealClient.getInstance()
        getMeal()

        clickListener()
    }

    private fun clickListener(){
        main_addItem.setOnClickListener {
            simIntentNoFinish(AddActivity::class.java)
        }
    }
    //급식 정보를 받아오는 코드
    fun getMeal(){
        val now : Long = System.currentTimeMillis()
        val date : Date = Date(now)
        val dateFormat : SimpleDateFormat = SimpleDateFormat("yyyyMMdd")
        val getTime :String = dateFormat.format(date)

        Log.d("Logg", getTime)

        mealAPI = mealRetrofit.create(MealService::class.java)
        mealAPI.getMeal(schoolID, officeCode, getTime)
            .enqueue(object : Callback<Response<Meal>>{
                override fun onResponse(call: Call<Response<Meal>>, response: retrofit2.Response<Response<Meal>>) {
                    breakfast_menu.text = Html.fromHtml(response.body()?.data?.meals?.get(0))
                    lunch_menu.text = Html.fromHtml(response.body()?.data?.meals?.get(1))
                    dinner_menu.text = Html.fromHtml(response.body()?.data?.meals?.get(2))
                    Log.d("Logg",response.body()?.data?.meals?.get(1))
                }

                override fun onFailure(call: Call<Response<Meal>>, t: Throwable) {
                    Log.d("Logg", t.message)
                }
            })
    }
}