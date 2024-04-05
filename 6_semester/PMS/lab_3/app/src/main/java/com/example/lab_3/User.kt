package com.example.lab_3

class User {
    var id = 0
    var name = ""
    var age = 0

    constructor() {}

    constructor(name: String, age: Int) {
        this.name = name
        this.age = age
    }

    constructor(id: Int, name: String, age: Int) {
        this.id = id
        this.name = name
        this.age = age
    }
}
