package com.P4;

import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.CharStreams;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTree;

import java.io.IOException;

public class Main {

    public static void main(String[] args) {
        try {
            CharStream charStream = CharStreams.fromFileName("./P4-input.txt");
            P4Lexer p4Lexer = new P4Lexer(charStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(p4Lexer);
            P4Parser p4Parser = new P4Parser(commonTokenStream);

            ParseTree parseTree = p4Parser.program();

            System.out.println("done");
        }
        catch (IOException e) {
            System.out.println("Can't find file!");
        }
    }
}
