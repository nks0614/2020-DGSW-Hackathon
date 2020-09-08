package com.project.hackathon.network

import com.project.hackathon.data.TotalWeather
import com.project.hackathon.data.Weather
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query

interface WeatherService {

    @GET("data/2.5/weather/")
    fun getWeather(
        @Query("lat") lat : Double,
        @Query("lon") lon : Double,
        @Query("APPID") appID : String,
        @Query("units") units : String
    ): Call<TotalWeather>

}