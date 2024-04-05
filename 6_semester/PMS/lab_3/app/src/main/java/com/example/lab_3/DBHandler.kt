package com.example.lab_3

import android.content.Context
import android.content.ContentValues
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import android.widget.Toast

const val DATABASE_NAME = "MyDB"
const val TABLE_NAME = "Users"
const val COL_NAME = "name"
const val COL_AGE = "age"
const val COL_ID = "id"

class DBHandler(var context: Context) : SQLiteOpenHelper(context, DATABASE_NAME, null, 1) {
    override fun onCreate(db: SQLiteDatabase?) {
        val createTable = "CREATE TABLE " + TABLE_NAME +" (" +
                COL_ID +" INTEGER PRIMARY KEY AUTOINCREMENT," +
                COL_NAME + " VARCHAR(256)," +
                COL_AGE +" INTEGER)"

        db?.execSQL(createTable)

        if (db != null) {
            insertStaticData(db)
        }
    }

    private fun insertStaticData(db: SQLiteDatabase) {
        val users = listOf(
            User("Misha", 24),
            User("Dima", 22),
            User("Lesha", 20),
            User("Sergey", 17),
            User("Alesya", 14)
        )
        for (user in users) {
            val cv = ContentValues()
            cv.put(COL_NAME, user.name)
            cv.put("age", user.age)
            db.insert(TABLE_NAME, null, cv)
        }
    }

    override fun onUpgrade(db: SQLiteDatabase?, oldVersion: Int, newVersion: Int) {
        db?.execSQL("DROP TABLE IF EXISTS $TABLE_NAME")
        onCreate(db)
    }

    fun insertData(user: User) {
        val db = this.writableDatabase
        var cv = ContentValues()
        cv.put(COL_NAME, user.name)
        cv.put(COL_AGE, user.age)
        var result = db.insert(TABLE_NAME, null, cv)

        if (result == (-1).toLong()) {
            Toast.makeText(context, "Failed", Toast.LENGTH_SHORT).show()
        } else {
            Toast.makeText(context, "Success", Toast.LENGTH_SHORT).show()
        }
    }

    fun readData() : MutableList<User>{
        var list : MutableList<User> = ArrayList()

        val db = this.readableDatabase
        val query = "Select * from $TABLE_NAME"
        val result = db.rawQuery(query,null)
        if(result.moveToFirst()){
            do {
                var user = User()
                user.id = result.getString(result.getColumnIndexOrThrow(COL_ID)).toInt()
                user.name = result.getString(result.getColumnIndexOrThrow(COL_NAME))
                user.age = result.getString(result.getColumnIndexOrThrow(COL_AGE)).toInt()
                list.add(user)
            } while (result.moveToNext())
        }

        result.close()
        db.close()
        return list
    }

    fun getUser(id: Int): User {
        val db = this.readableDatabase
        val cursor = db.query("users", null, "id = ?",
            arrayOf(id.toString()), null, null, null)

        if (cursor.moveToFirst()) {
            val name = cursor.getString(cursor.getColumnIndexOrThrow("name"))
            val age = cursor.getInt(cursor.getColumnIndexOrThrow("age"))
            return User(name, age)
        } else {
            throw IllegalArgumentException("No user with ID $id")
        }
    }

    fun updateUser(user: User) {
        val db = this.writableDatabase
        val values = ContentValues().apply {
            put("name", user.name)
            put("age", user.age)
        }
        db.update("users", values, "id = ?", arrayOf(user.id.toString()))
    }

    fun deleteById(id: Int): Boolean {
        val db = this.writableDatabase
        val success = db.delete(TABLE_NAME, "$COL_ID=?", arrayOf(id.toString()))
        db.close()
        return Integer.parseInt("$success") != -1
    }
}
