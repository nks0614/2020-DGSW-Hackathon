package com.project.hackathon.data

data class Meal(
    val meals: ArrayList<String?>
)

data class Schedule(
    val schedules : List<DetailSchedule>
)

data class DetailSchedule(
    val name: String,
    val date: String
)