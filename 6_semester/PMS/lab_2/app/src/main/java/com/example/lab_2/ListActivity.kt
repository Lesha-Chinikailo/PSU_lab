package com.example.lab_2

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.ListView
import android.widget.Toast

class ListActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        val stationsArray = resources.getStringArray(R.array.stations)

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, stationsArray)

        val listView = ListView(this)
        listView.adapter = adapter

        setContentView(listView)

        listView.setOnItemClickListener { parent, view, position, id ->
            val selectedItem = parent.getItemAtPosition(position).toString()
            Toast.makeText(applicationContext, selectedItem, Toast.LENGTH_LONG).show()
        }
    }
}