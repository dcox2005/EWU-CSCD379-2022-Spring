<template>
  <v-row justify="center" align="center">
    <v-card color="slate" ripple>
      <v-card-title class="display-1">
        Welcome to the Enigma Vocabulary!
      </v-card-title>
      <v-card-text>
        <p class="headline">
          I want to play a game!
        </p>
        <p class="body-1">
          Here are the rules:<br>
          1)Your guess has to be a real word. No random letters.<br>
          2)Gray letters are not found in the word at all.<br>
          3)Yellow letter are correct guesses but in the wrong spot.<br>
          4)Green letters are correct guesses in the correct spot. Don't move them.<br>
          5)Words can have multiples of the same letter, ex: Apple<br>
          6)You have {{maxTries}} tries to guess the correct word.<br>
        </p>
        <p class="display-1">
          Now let's play a game!
        </p>
      </v-card-text>
      <v-card-actions>
        <v-col class="text-left">
          <v-btn color="primary" :loading="getWordLoading" @click="getWord">
            {{getWordButtonText}}
          </v-btn>
        </v-col>

        <v-col class="text-center">
          <v-btn color="secondary" :loading="solveWordLoading" @click="solveWord">
            {{solveWordButtonText}}
          </v-btn>
        </v-col>

        <v-col class="text-right">
          <v-btn color="purple" href="./">
            Return to main page
          </v-btn>
        </v-col>
        <div>
            <v-btn color="blue" href="https://qntm.org/files/absurdle/absurdle.html" target="_blank">
            Try another game
          </v-btn>
          </div>
      </v-card-actions>
      <p align="center">
        Based on the game <a href="https://www.nytimes.com/games/wordle/index.html" target="_blank">Wordle</a>
      </p>
    </v-card>
  </v-row>
</template>

<script lang="ts">
import Vue from "vue"
import Component from "vue-class-component"

@Component
export default class gamePage extends Vue{
    name: string = 'GamePage';
    getWordButtonText: string = "Get Your Word";
    solveWordButtonText: string = "Solve Word";
    getWordLoading: boolean = false;
    solveWordLoading: boolean = false;
    maxTries: number = 5;

    solveWord() {
        this.solveWordButtonText = this.solveWordButtonText === 'Solve Word' ? 'Word Solved' : 'Solve Word';
        this.solveWordLoading = true;
        setTimeout(() => {
            this.solveWordLoading = false;
        }, 1000);
    }
    getWord()
    {
        this.getWordButtonText = this.getWordButtonText === 'Get Your Word' ? 'Word Retrieved' : 'Get Your Word';
        this.getWordLoading = true;
        setTimeout(() => {
            this.getWordLoading = false;
        }, 1000);
    }
}
</script>