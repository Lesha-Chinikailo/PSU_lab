package com.example.lab_1;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class ActivityWithWidget2 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.list_item);

        TextView selection = findViewById(R.id.selection);
        ListView countriesList = findViewById(R.id.countriesList);

        String[] stations = getResources().getStringArray(R.array.stations);
        ArrayAdapter<String> adapter = new ArrayAdapter(this,
                android.R.layout.activity_list_item, stations);
        countriesList.setAdapter(adapter);
        countriesList.setOnItemClickListener(new AdapterView.OnItemClickListener(){
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id)
            {
                CharSequence text = ((TextView) v).getText();
                int duration = Toast.LENGTH_SHORT;
                Context context = getApplicationContext();
                Toast.makeText(context, text, duration).show();
            }
        });
    }
}