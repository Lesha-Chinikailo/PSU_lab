package com.example.lab_2

import android.os.Bundle
import android.view.LayoutInflater
import android.widget.TabHost
import androidx.activity.ComponentActivity

class TabWidgetActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_tab_widget)

        setupTabs()
    }

    private fun setupTabs() {
        val tabHost = findViewById<TabHost>(android.R.id.tabhost)
        tabHost.setup()

        val inflater = LayoutInflater.from(this)

        val tab1View = inflater.inflate(R.layout.tab1_content, null)
        val tab2View = inflater.inflate(R.layout.tab2_content, null)

        val tab1 = tabHost.newTabSpec("Tab 1")
        tab1.setIndicator("Tab 1")
        tab1.setContent { tab1View }
        tabHost.addTab(tab1)

        val tab2 = tabHost.newTabSpec("Tab 2")
        tab2.setIndicator("Tab 2")
        tab2.setContent { tab2View }
        tabHost.addTab(tab2)

        tabHost.currentTab = 0
    }
}
