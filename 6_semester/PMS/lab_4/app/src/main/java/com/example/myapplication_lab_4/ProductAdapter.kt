package com.example.myapplication_lab_4

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class ProductAdapter(private var users: List<Product>) : RecyclerView.Adapter<ProductAdapter.ProductViewHolder>() {
    var onItemClick : ((Product) -> Unit)? = null
    var onItemLongClick : ((Product) -> Unit)? = null
    var selectedPosition = -1

    class ProductViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val textView: TextView = itemView.findViewById(R.id.text_view)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ProductViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.list_item, parent, false)
        return ProductViewHolder(view)
    }

    override fun getItemCount(): Int {
        return users.size
    }

    override fun onBindViewHolder(holder: ProductViewHolder, position: Int) {
        val user = users[position]
        holder.textView.text = "${user.name}, ${user.price}"

        holder.itemView.setOnClickListener {
            onItemClick?.invoke(user)
        }

        holder.itemView.setOnLongClickListener {
            selectedPosition = position
            onItemLongClick?.invoke(user)
            false
        }
    }

    fun getSelectedUser(): Product {
        return users[selectedPosition]
    }

    fun updateUsers(newUsers: List<Product>) {
        this.users = newUsers
        notifyDataSetChanged()
    }
}
