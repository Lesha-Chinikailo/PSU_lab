package com.example.myapplication_lab_4

import android.annotation.SuppressLint
import android.app.Activity
import android.content.ContentValues
import android.content.Context
import android.content.Intent
import android.content.Intent.ACTION_VIEW
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
import androidx.activity.result.contract.ActivityResultContracts

class DBActivity : AppCompatActivity() {
    private lateinit var recyclerView: RecyclerView
    private lateinit var productAdapter: ProductAdapter
    private lateinit var dbHandler: DBHandler

    @SuppressLint("MissingInflatedId")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_dbactivity)

        var btnInsert = findViewById<Button>(R.id.btnInsert)
        var etvName = findViewById<EditText>(R.id.etvName)
        var etvPrice = findViewById<EditText>(R.id.etvPrice)

        btnInsert.setOnClickListener {
            if (etvName.text.toString().isNotEmpty() &&
                etvPrice.text.toString().isNotEmpty()
            ) {
                var product = Product(etvName.text.toString(), etvPrice.text.toString().toInt())
                etvName.text.clear()
                etvPrice.text.clear()

                dbHandler.insertData(product)
                updateUsers()

                val imm = getSystemService(Context.INPUT_METHOD_SERVICE) as InputMethodManager
                imm.hideSoftInputFromWindow(it.windowToken, 0)
            } else {
                Toast.makeText(this, "Please fill all fields", Toast.LENGTH_SHORT).show()
            }
        }

        var btnToList = findViewById<Button>(R.id.btnToList)

        btnToList.setOnClickListener {
            //Toast.makeText(this, "To lIst", Toast.LENGTH_SHORT).show()
            val intent = Intent("ListDB")
            intent.putExtra("callingActivity", "DBActivity")
            listActivityResult.launch(intent)
            //startActivity(intent)
        }


        recyclerView = findViewById(R.id.recycler_view)
        recyclerView.setHasFixedSize(true)
        recyclerView.layoutManager = LinearLayoutManager(this)

        dbHandler = DBHandler(this)
        var products = dbHandler.readData()

        productAdapter = ProductAdapter(products)
        recyclerView.adapter = productAdapter

        productAdapter.onItemClick = {
            //Toast.makeText(this, "User ID: ${it.id}", Toast.LENGTH_LONG).show()

            val intent = Intent(this, EditProductActivity::class.java)
            intent.putExtra("USER_ID", it.id)
            intent.putExtra("callingActivity", "DBActivity")
            editActivityResult.launch(intent)
            //startActivity(intent)
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

    private val listActivityResult = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            val fromActivity = result.data?.getStringExtra("fromActivity")
            val name = result.data?.getStringExtra("name")
            Toast.makeText(this, "сообщение пришло от ${fromActivity}.", Toast.LENGTH_SHORT).show()
            Toast.makeText(this, "сообщение: ${name}", Toast.LENGTH_SHORT).show()
        }
    }

    private val editActivityResult = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            val fromActivity = result.data?.getStringExtra("fromActivity")
            Toast.makeText(this, "возвратились от ${fromActivity}.", Toast.LENGTH_SHORT).show()
        }
    }

    override fun onResume() {
        super.onResume()
        updateUsers()
    }

    private fun updateUsers() {
        val users = dbHandler.readData()
        productAdapter.updateUsers(users)
    }

    override fun onCreateContextMenu(menu: ContextMenu, v: View, menuInfo: ContextMenu.ContextMenuInfo?) {
        super.onCreateContextMenu(menu, v, menuInfo)
        menu.add(0, v.id, 0, "Удалить")
        menu.add(0, v.id, 0, "Изменить")
    }

    override fun onContextItemSelected(item: MenuItem): Boolean {
        if (item.title == "Удалить") {
            val user = productAdapter.getSelectedUser()
            dbHandler.deleteById(user.id)

            val users = dbHandler.readData()
            productAdapter.updateUsers(users)
        }
        if(item.title == "Изменить"){
            val user = productAdapter.getSelectedUser()
            //Toast.makeText(this, "User ID: ${user.id}", Toast.LENGTH_LONG).show()

            val intent = Intent(this, EditProductActivity::class.java)
            intent.putExtra("USER_ID", user.id)
            intent.putExtra("callingActivity", "DBActivity")
            editActivityResult.launch(intent)
            //startActivity(intent)
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
        var etvPrice = findViewById<EditText>(R.id.etvPrice)

        btnInsert.setOnClickListener {
            if (etvName.text.toString().isNotEmpty() &&
                etvPrice.text.toString().isNotEmpty()
            ) {
                var user = User(etvName.text.toString(), etvPrice.text.toString().toInt())
                etvName.text.clear()
                etvPrice.text.clear()

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