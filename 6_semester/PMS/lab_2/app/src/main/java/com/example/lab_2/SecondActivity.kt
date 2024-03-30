package com.example.lab_2

import android.annotation.SuppressLint
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.Toast

class SecondActivity : AppCompatActivity() {
    @SuppressLint("MissingInflatedId")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_second)
        val button1 = findViewById<Button>(R.id.ok)
        button1.setOnClickListener{
            Toast.makeText(this, "you click on button Ok", Toast.LENGTH_LONG).show();
        }
        val button2 = findViewById<Button>(R.id.cancel)
        button2.setOnClickListener{
            Toast.makeText(this, "you click on button cancel", Toast.LENGTH_LONG).show();
        }
    }
}