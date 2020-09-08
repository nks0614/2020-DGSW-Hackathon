package com.project.hackathon

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.project.hackathon.data.Check
import com.project.hackathon.room.DataBase
import com.project.simplecode.simIntent
import kotlinx.android.synthetic.main.activity_add.*

class AddActivity : AppCompatActivity() {

    var checkDB : DataBase? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add)

        checkDB = DataBase.getInstance(this)

        add_button.setOnClickListener {
            checkDB?.dao()?.insert(Check(0, add_edit.text.toString()))
            simIntent(MainActivity::class.java)
        }
    }
}