package com.example.myapplication_lab_4

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast

class EditProductActivity : AppCompatActivity() {
    private lateinit var dbHandler: DBHandler
    private lateinit var user: Product

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_edit_product)

        var nameEditText: EditText = findViewById(R.id.name_edit_text)
        var ageEditText: EditText = findViewById(R.id.age_edit_text)
        var saveButton: Button = findViewById(R.id.save_button)

        dbHandler = DBHandler(this)

        val userId = intent.getIntExtra("USER_ID", -1)
        if (userId == -1) {
            Toast.makeText(this, "Invalid product ID", Toast.LENGTH_LONG).show()
            finish()
            return
        }
        val callingActivity = intent.getStringExtra("callingActivity")
        if(callingActivity == null){
            Toast.makeText(this, "Invalid callingActivity", Toast.LENGTH_LONG).show()
        }
        else{
            Toast.makeText(this, "Вызвала: ${callingActivity}", Toast.LENGTH_LONG).show()
        }

        user = dbHandler.getUser(userId)
        nameEditText.setText(user.name)
        ageEditText.setText(user.price.toString())

        saveButton.setOnClickListener {
            val name = nameEditText.text.toString()
            val price = ageEditText.text.toString().toIntOrNull()
            if (name.isBlank() || price == null) {
                Toast.makeText(this, "Please enter valid data", Toast.LENGTH_LONG).show()
                return@setOnClickListener
            }

            user.id = userId
            user.name = name
            user.price = price
            dbHandler.updateUser(user)

            Toast.makeText(this, "product updated", Toast.LENGTH_LONG).show()
            val resultIntent = Intent().apply {
                putExtra("fromActivity", "EditProductActivity")
            }
            setResult(Activity.RESULT_OK, resultIntent)
            finish()
        }
    }
}
