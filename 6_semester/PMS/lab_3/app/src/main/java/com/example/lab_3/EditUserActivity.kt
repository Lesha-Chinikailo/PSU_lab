package com.example.lab_3

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast

class EditUserActivity : AppCompatActivity() {
    private lateinit var dbHandler: DBHandler
    private lateinit var user: User

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_edit_user)

        var nameEditText: EditText = findViewById(R.id.name_edit_text)
        var ageEditText: EditText = findViewById(R.id.age_edit_text)
        var saveButton: Button = findViewById(R.id.save_button)

        dbHandler = DBHandler(this)

        val userId = intent.getIntExtra("USER_ID", -1)
        if (userId == -1) {
            Toast.makeText(this, "Invalid user ID", Toast.LENGTH_LONG).show()
            finish()
            return
        }

        user = dbHandler.getUser(userId)
        nameEditText.setText(user.name)
        ageEditText.setText(user.age.toString())

        saveButton.setOnClickListener {
            val name = nameEditText.text.toString()
            val age = ageEditText.text.toString().toIntOrNull()
            if (name.isBlank() || age == null) {
                Toast.makeText(this, "Please enter valid data", Toast.LENGTH_LONG).show()
                return@setOnClickListener
            }

            user.id = userId
            user.name = name
            user.age = age
            dbHandler.updateUser(user)

            Toast.makeText(this, "User updated", Toast.LENGTH_LONG).show()
            finish()
        }
    }
}
