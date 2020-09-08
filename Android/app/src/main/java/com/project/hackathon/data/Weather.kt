package com.project.hackathon.data

import com.google.gson.annotations.SerializedName
import java.io.Serializable

data class TotalWeather(
    var main : Main? = null,
    @SerializedName("weather")
    var weatherList : ArrayList<Weather>? = null

): Serializable

data class Weather(
    var description : String? = null,
    var icon : String? = null,
    var id : Int? = null,
    var main : String? = null
): Serializable

data class Main(
    var humidity : Int? = null,
    var pressure : Int? = null,
    var temp : Float? = null,
    var temp_max : Float? = null,
    var temp_min : Float? = null
): Serializable