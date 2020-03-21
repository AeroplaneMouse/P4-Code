package com.shizu;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	    try {
	        BufferedReader reader = new BufferedReader(new FileReader("./input.txt"));
            search lexer = new search(reader);
			List<Yytoken> list = new ArrayList<Yytoken>();
            while (!lexer.yyatEOF()){
				list.add(lexer.yylex());
			}
            for(int i = 0; i < list.size() - 1; ++i){
            	System.out.println(list.get(i).m_text);
			}
	    }
	    catch (FileNotFoundException e) {
	        e.printStackTrace();
	    }
	    catch (IOException e) {
	    	e.printStackTrace();
		}
    }
}

