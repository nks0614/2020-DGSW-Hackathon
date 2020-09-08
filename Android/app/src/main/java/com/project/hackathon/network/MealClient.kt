package com.project.hackathon.network

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object MealClient {
    private var instance: Retrofit? = null

    fun getInstance(): Retrofit {
        if (instance == null) {
            instance = Retrofit.Builder()
                .baseUrl("http://kyungwon-server.kro.kr:8080/")
                .addConverterFactory(GsonConverterFactory.create())
                .build()
        }
        return instance!!
    }
}