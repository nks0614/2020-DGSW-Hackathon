package com.project.hackathon

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.project.simplecode.simIntent

class SplashActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        simIntent(MainActivity::class.java)
    }
}