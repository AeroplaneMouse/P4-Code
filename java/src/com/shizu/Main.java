package com.shizu;
import java.io.*;

public class Main {

    public static void main(String[] args) {
	    try {
	        BufferedReader reader = new BufferedReader(new FileReader("./input.txt"));
            search lexer = new search(reader);
            Yytoken token = lexer.yylex();
            Yytoken token2 = lexer.yylex(); /* We need to call this method multiple times */
            System.out.println(token.m_text);
            System.out.println(token2.m_text);
	    }
	    catch (FileNotFoundException e) {
	        e.printStackTrace();
	    }
	    catch (IOException e) {
	    	e.printStackTrace();
		}
    }
}

