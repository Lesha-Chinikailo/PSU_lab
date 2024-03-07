package com.example.lab_1

import android.R
import android.os.Bundle
import android.widget.AdapterView.OnItemClickListener
import android.widget.ArrayAdapter
import android.widget.ListView
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity


class ListActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_list_item)
        val selection = findViewById<TextView>(R.id.selection)
        val countriesList = findViewById<ListView>(R.id.countriesList)
        val stations = resources.getStringArray(R.array.stations)
        val adapter: ArrayAdapter<Any?> = ArrayAdapter<Any?>(
            this,
            R.layout.simple_list_item_1, stations
        )
        countriesList.adapter = adapter
        countriesList.onItemClickListener =
            OnItemClickListener { parent, v, position, id ->
                val text = (v as TextView).text
                val duration = Toast.LENGTH_SHORT
                val context = applicationContext
                Toast.makeText(context, text, duration).show()
            }
    }
}