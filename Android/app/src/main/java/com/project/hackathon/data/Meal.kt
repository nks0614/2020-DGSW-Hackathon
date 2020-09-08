package com.project.hackathon.data

class Meal(
    val meals: ArrayList<String?>
)

class Schedule(
    val schedules : List<DetailSchedule>
)

class DetailSchedule(
    val name: String,
    val date: String
)