package com.example.lab_3

class User {
    var id = 0
    var name = ""
    var price = 0

    constructor() {}

    constructor(name: String, price: Int) {
        this.name = name
        this.price = price
    }

    constructor(id: Int, name: String, price: Int) {
        this.id = id
        this.name = name
        this.price = price
    }
}
