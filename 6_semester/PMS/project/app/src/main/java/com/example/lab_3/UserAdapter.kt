package com.example.lab_3

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class UserAdapter(private var users: List<User>) : RecyclerView.Adapter<UserAdapter.UserViewHolder>() {
    var onItemClick : ((User) -> Unit)? = null
    var onItemLongClick : ((User) -> Unit)? = null
    var selectedPosition = -1

    class UserViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val textView: TextView = itemView.findViewById(R.id.text_view)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UserViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.list_item, parent, false)
        return UserViewHolder(view)
    }

    override fun getItemCount(): Int {
        return users.size
    }

    override fun onBindViewHolder(holder: UserViewHolder, position: Int) {
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

    fun getSelectedUser(): User {
        return users[selectedPosition]
    }

    fun updateUsers(newUsers: List<User>) {
        this.users = newUsers
        notifyDataSetChanged()
    }
}
