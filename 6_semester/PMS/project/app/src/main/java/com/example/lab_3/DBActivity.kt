package com.example.lab_3

import android.content.Context
import android.content.Intent
import android.graphics.Rect
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.TypedValue
import android.view.ContextMenu
import android.view.MenuItem
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import android.view.inputmethod.InputMethodManager

class DBActivity : AppCompatActivity() {
    private lateinit var recyclerView: RecyclerView
    private lateinit var userAdapter: UserAdapter
    private lateinit var dbHandler: DBHandler

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_dbactivity)

        var btnInsert = findViewById<Button>(R.id.btnInsert)
        var etvName = findViewById<EditText>(R.id.etvName)
        var etvAge = findViewById<EditText>(R.id.etvAge)

        btnInsert.setOnClickListener {
            if (etvName.text.toString().isNotEmpty() &&
                etvAge.text.toString().isNotEmpty()
            ) {
                var user = User(etvName.text.toString(), etvAge.text.toString().toInt())
                etvName.text.clear()
                etvAge.text.clear()

                dbHandler.insertData(user)
                updateUsers()

                val imm = getSystemService(Context.INPUT_METHOD_SERVICE) as InputMethodManager
                imm.hideSoftInputFromWindow(it.windowToken, 0)
            } else {
                Toast.makeText(this, "Please fill all fields", Toast.LENGTH_SHORT).show()
            }
        }

        recyclerView = findViewById(R.id.recycler_view)
        recyclerView.setHasFixedSize(true)
        recyclerView.layoutManager = LinearLayoutManager(this)

        dbHandler = DBHandler(this)
        var users = dbHandler.readData()

        userAdapter = UserAdapter(users)
        recyclerView.adapter = userAdapter

        userAdapter.onItemClick = {
            Toast.makeText(this, "User ID: ${it.id}", Toast.LENGTH_LONG).show()

            val intent = Intent(this, EditUserActivity::class.java)
            intent.putExtra("USER_ID", it.id)
            startActivity(intent)
        }


        recyclerView.addItemDecoration(object : RecyclerView.ItemDecoration() {
            override fun getItemOffsets(outRect: Rect, view: View, parent: RecyclerView, state: RecyclerView.State) {
                super.getItemOffsets(outRect, view, parent, state)

                val position = parent.getChildAdapterPosition(view)
                val isLastItem = position == state.itemCount - 1

                if (!isLastItem) {
                    outRect.bottom = 10.dpToPx(parent.context)
                }
            }
        })

        registerForContextMenu(recyclerView)
    }

    override fun onResume() {
        super.onResume()
        updateUsers()
    }

    private fun updateUsers() {
        val users = dbHandler.readData()
        userAdapter.updateUsers(users)
    }

    override fun onCreateContextMenu(menu: ContextMenu, v: View, menuInfo: ContextMenu.ContextMenuInfo?) {
        super.onCreateContextMenu(menu, v, menuInfo)
        menu.add(0, v.id, 0, "Удалить")
        menu.add(0, v.id, 0, "Изменить")
    }

    override fun onContextItemSelected(item: MenuItem): Boolean {
        if (item.title == "Удалить") {
            val user = userAdapter.getSelectedUser()
            dbHandler.deleteById(user.id)

            val users = dbHandler.readData()
            userAdapter.updateUsers(users)
        }
        if(item.title == "Изменить"){
            val user = userAdapter.getSelectedUser()
            Toast.makeText(this, "User ID: ${user.id}", Toast.LENGTH_LONG).show()

            val intent = Intent(this, EditUserActivity::class.java)
            intent.putExtra("USER_ID", user.id)
            startActivity(intent)
        }
        return super.onContextItemSelected(item)
    }

    private fun Int.dpToPx(context: Context): Int {
        val metrics = context.resources.displayMetrics
        return TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, this.toFloat(), metrics)
            .toInt()
    }
}





/*
package com.example.lab_3

import android.content.Context
import android.content.Intent
import android.graphics.Rect
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.TypedValue
import android.view.ContextMenu
import android.view.MenuItem
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import android.view.inputmethod.InputMethodManager

class DBActivity : AppCompatActivity() {
    private lateinit var recyclerView: RecyclerView
    private lateinit var userAdapter: UserAdapter
    private lateinit var dbHandler: DBHandler

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_dbactivity)

        var btnInsert = findViewById<Button>(R.id.btnInsert)
        var etvName = findViewById<EditText>(R.id.etvName)
        var etvAge = findViewById<EditText>(R.id.etvAge)

        btnInsert.setOnClickListener {
            if (etvName.text.toString().isNotEmpty() &&
                etvAge.text.toString().isNotEmpty()
            ) {
                var user = User(etvName.text.toString(), etvAge.text.toString().toInt())
                etvName.text.clear()
                etvAge.text.clear()

                dbHandler.insertData(user)
                updateUsers()

                val imm = getSystemService(Context.INPUT_METHOD_SERVICE) as InputMethodManager
                imm.hideSoftInputFromWindow(it.windowToken, 0)
            } else {
                Toast.makeText(this, "Please fill all fields", Toast.LENGTH_SHORT).show()
            }
        }

        recyclerView = findViewById(R.id.recycler_view)
        recyclerView.setHasFixedSize(true)
        recyclerView.layoutManager = LinearLayoutManager(this)

        dbHandler = DBHandler(this)
        var users = dbHandler.readData()

        userAdapter = UserAdapter(users)
        recyclerView.adapter = userAdapter

        userAdapter.onItemClick = {
            Toast.makeText(this, "User ID: ${it.id}", Toast.LENGTH_LONG).show()

            val intent = Intent(this, EditUserActivity::class.java)
            intent.putExtra("USER_ID", it.id)
            startActivity(intent)
        }

        userAdapter.onItemLongClick = {
            Toast.makeText(this, "long User ID: ${it.id}", Toast.LENGTH_LONG).show()
        }

        recyclerView.addItemDecoration(object : RecyclerView.ItemDecoration() {
            override fun getItemOffsets(outRect: Rect, view: View, parent: RecyclerView, state: RecyclerView.State) {
                super.getItemOffsets(outRect, view, parent, state)

                val position = parent.getChildAdapterPosition(view)
                val isLastItem = position == state.itemCount - 1

                if (!isLastItem) {
                    outRect.bottom = 10.dpToPx(parent.context)
                }
            }
        })

        registerForContextMenu(recyclerView)
    }

    override fun onResume() {
        super.onResume()
        updateUsers()
    }

    private fun updateUsers() {
        val users = dbHandler.readData()
        userAdapter.updateUsers(users)
    }

    override fun onCreateContextMenu(menu: ContextMenu, v: View, menuInfo: ContextMenu.ContextMenuInfo?) {
        super.onCreateContextMenu(menu, v, menuInfo)
        menu.add(0, v.id, 0, "Удалить")
    }

    override fun onContextItemSelected(item: MenuItem): Boolean {
        if (item.title == "Удалить") {
            val user = userAdapter.getSelectedUser()
            dbHandler.deleteById(user.id)

            val users = dbHandler.readData()
            userAdapter.updateUsers(users)
        }
        return super.onContextItemSelected(item)
    }

    private fun Int.dpToPx(context: Context): Int {
        val metrics = context.resources.displayMetrics
        return TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, this.toFloat(), metrics)
            .toInt()
    }
}

*/