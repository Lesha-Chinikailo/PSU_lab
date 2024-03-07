package com.example.lab_2

import android.content.Intent
import androidx.activity.ComponentActivity
import android.os.Bundle
import android.webkit.WebView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import android.widget.Toast

class MainActivity : ComponentActivity() {
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
//}
