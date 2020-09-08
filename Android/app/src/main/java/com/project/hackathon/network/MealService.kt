package com.project.hackathon.network

import com.project.hackathon.data.Meal
import com.project.hackathon.data.Response
import com.project.hackathon.data.Schedule
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query

interface MealService {

    @GET("meals")
    fun getMeal(
        @Query("school_id") id : String,
        @Query("office_code") code : String,
        @Query("date") date: String
    ): Call<Response<Meal>>

    @GET("schedule")
    fun getSchedule(
        @Query("school_id") id : String,
        @Query("office_code") code : String,
        @Query("date") date : String
    ): Call<Response<Schedule>>

}