package com.example.lab_3

import android.annotation.SuppressLint
import android.os.Bundle
import android.view.KeyEvent
import android.view.View
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import android.widget.RadioButton
import android.widget.Toast
import android.widget.ToggleButton
import androidx.activity.ComponentActivity
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import com.example.lab_3.ui.theme.Lab_3Theme

class MainActivity : ComponentActivity() {
    @SuppressLint("MissingInflatedId")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.main);
        val userName = findViewById<EditText>(R.id.user_name)
        userName.setOnKeyListener { v, keyCode, event ->
            if (event.action == KeyEvent.ACTION_DOWN && keyCode == KeyEvent.KEYCODE_ENTER) {
                Toast.makeText(applicationContext, userName.text, Toast.LENGTH_SHORT).show()
                true
            } else {
                false
            }
        }
    }
    fun onButtonClicked(v: View) {
        Toast.makeText(this, "Кнопка нажата", Toast.LENGTH_SHORT).show()
    }
    fun onCheckboxClicked(v: View) {
        if ((v as CheckBox).isChecked) {
            Toast.makeText(this, "Отмечено", Toast.LENGTH_SHORT).show()
        } else {
            Toast.makeText(this, "Не отмечено", Toast.LENGTH_SHORT).show()
        }
    }
    fun onToggleClicked(v: View) {
        if ((v as ToggleButton).isChecked) {
            Toast.makeText(this, "Включено", Toast.LENGTH_SHORT).show()
        } else {
            Toast.makeText(this, "Выключено", Toast.LENGTH_SHORT).show()
        }
    }
    fun onRadioButtonClicked(v: View) {
        val rb = v as RadioButton
        Toast.makeText(this, "Выбрано животное: ${rb.text}", Toast.LENGTH_SHORT).show()
    }

}
@Composable
fun Greeting(name: String, modifier: Modifier = Modifier) {
    Text(
        text = "Hello $name!",
        modifier = modifier
    )
}

@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    Lab_3Theme {
        Greeting("Android")
    }
}