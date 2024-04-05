package com.example.lab_3

import android.R
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.ListView
import android.widget.Toast

class SQLClass(context : Context) : SQLiteOpenHelper(context, DATABASE_NAME, null, DATABASE_VERSION) {

    companion object {
        private const val DATABASE_NAME = "my_database"
        private const val DATABASE_VERSION = 1
        const val TABLE_NAME = "my_table"
        const val COLUMN_ID = "_id"
        const val COLUMN_NAME = "name"
    }
    override fun onCreate(db: SQLiteDatabase?) {
        val createTableQuery = "CREATE TABLE $TABLE_NAME ($COLUMN_ID INTEGER PRIMARY KEY AUTOINCREMENT, $COLUMN_NAME TEXT)"
        db?.execSQL(createTableQuery)
    }
    override fun onUpgrade(db: SQLiteDatabase?, oldVersion: Int, newVersion: Int) {
        db?.execSQL("DROP TABLE IF EXISTS $TABLE_NAME")
        onCreate(db)
    }
}
class SecondActivity : AppCompatActivity() {
    private lateinit var dbHelper: SQLClass

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
//        setContentView(R.layout.activity_second) // Подставьте имя вашего макета
//
//// Создание или открытие базы данных
//        dbHelper = SQLClass(this)
//
//// Запрос данных и запись в массив строк
//        val data = mutableListOf<String>()
//        val db = dbHelper.readableDatabase
//        val cursor = db.query("MyTable", arrayOf("_id", "name"), null, null, null, null, null)
//        while (cursor.moveToNext()) {
//            val name = cursor.getString(cursor.getColumnIndex("name"))
//            data.add(name)
//        }
//        cursor.close()
//        db.close()
//        dropDatabase()
//        createDatabase()
//        insertData()
//
//        val listView = findViewById<ListView>(R.id.listView)
//        val newData = receiveData()
//        val newAdapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, newData)
//        listView.adapter = newAdapter
//
//        listView.onItemClickListener = AdapterView.OnItemClickListener { parent, view, position, id ->
//            val selectedItem = parent.getItemAtPosition(position) as String
//            val dataIndex = getIndexFromDatabase(selectedItem)
//            Toast.makeText(applicationContext, "Record index: $dataIndex", Toast.LENGTH_SHORT).show()
//        }
//
//        registerForContextMenu(listView)


//// Отображение данных с помощью ArrayAdapter
//        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, data)
//        listAdapter = adapter
//
//    }
//
//
//
//
//    private fun createDatabase() {
//        myDatabase = openOrCreateDatabase(DATABASE_NAME, MODE_PRIVATE, null)
//        myDatabase.execSQL(DATABASE_CREATE)
//    }
//
//    private fun dropDatabase() {
//        applicationContext.deleteDatabase(DATABASE_NAME)
//    }
//
//    private fun insertData() {
//        val values = ContentValues().apply {
//            put("username", "Ihar")
//        }
//        myDatabase.insert(DATABASE_TABLE, null, values)
//
//        values.clear()
//        values.put("username", "Kirill")
//        myDatabase.insert(DATABASE_TABLE, null, values)
//
//        values.clear()
//        values.put("username", "Roma")
//        myDatabase.insert(DATABASE_TABLE, null, values)
//    }
//
//    private fun receiveData(): ArrayList<String> {
//        val data = ArrayList<String>()
//        val cursor = myDatabase.query(DATABASE_TABLE, null, null, null, null, null, null)
//
//        if (cursor.moveToFirst()) {
//            do {
//                val columnOneValue = cursor.getString(cursor.getColumnIndex("username"))
//                data.add(columnOneValue)
//            } while (cursor.moveToNext())
//        }
//
//        cursor.close()
//        return data
//    }
//
//    private fun getIndexFromDatabase(selectedItem: String): Int {
//        var index = -1
//        val cursor = myDatabase.query(DATABASE_TABLE, arrayOf("_id"), "username=?", arrayOf(selectedItem), null, null, null)
//        if (cursor.moveToFirst()) {
//            index = cursor.getInt(cursor.getColumnIndex("_id"))
//        }
//        cursor.close()
//        return index
//    }
//
//
//    override fun onListItemClick(l: ListView?, v: View?, position: Int, id: Long) {
//        super.onListItemClick(l, v, position, id)
//        val selectedItem = l?.getItemAtPosition(position) as String
//// Здесь можно добавить логику для отображения индекса элемента с помощью Toast
    }
}

