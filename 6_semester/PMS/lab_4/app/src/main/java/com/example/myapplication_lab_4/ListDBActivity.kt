package com.example.myapplication_lab_4

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.ListView
import android.widget.Toast

class ListDBActivity : AppCompatActivity() {
    private lateinit var dbHandler: DBHandler

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_list_dbactivity)
        val callingActivity = intent.getStringExtra("callingActivity")
        Toast.makeText(this, "Вызвала: $callingActivity", Toast.LENGTH_SHORT).show()

        dbHandler = DBHandler(this)
        val stationsArray = dbHandler.readData()

        val products = mutableListOf<String>()
        for(product in stationsArray){
            products.add(product.name)
        }

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, products)

        val listView = ListView(this)
        listView.adapter = adapter

        setContentView(listView)

        listView.setOnItemClickListener { parent, view, position, id ->
            val selectedItem = parent.getItemAtPosition(position).toString()
            //Toast.makeText(applicationContext, selectedItem, Toast.LENGTH_LONG).show()
            val resultIntent = Intent().apply {
                putExtra("fromActivity", "EditActivity")
                putExtra("name", selectedItem)
            }
            setResult(Activity.RESULT_OK, resultIntent)
            finish()
        }
    }
}