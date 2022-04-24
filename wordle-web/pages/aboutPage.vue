<template>
  <v-container fluid fill-height justify-center>
    <v-row justify="center" align="center">
      <v-card color="slate" ripple>
        <v-card-title class="display-1">
          Welcome to the Enigma Vocabulary!
        </v-card-title>
        <v-card-text>
          <p class="headline">I want to play a game!</p>
          <p class="body-2">
            This is a web design class that is using the game of<br />
            wordle to show us how to create an interactive web app<br />
            that can be played and used on multiple platforms.<br />
            <br />
            Meg is our wonderful grader who is very nice and very<br />
            fair on her grading. She is great. The week Grant was<br />
            gone, was the best week we had!<br />
          </p>
          <p class="body-2">
            Here are the rules:<br />
            1)Your guess has to be a real word. No random letters.<br />
            2)Gray letters are not found in the word at all.<br />
            3)Yellow letter are correct guesses but in the wrong spot.<br />
            4)Green letters are correct guesses in the correct spot. Don't move
            them.<br />
            5)Words can have multiples of the same letter, ex: Apple<br />
            6)You have 6 tries to guess the correct word.<br />
          </p>
          <p class="display-1">Now let's play a game!</p>
        </v-card-text>
        <v-card-actions>
          <v-col class="text-right">
            <v-btn color="info" href="./game"> Play Game </v-btn>
          </v-col>
          <v-col class="text-middle">
            <v-btn color="primary" href="./"> Return to main page </v-btn>
          </v-col>
          <div>
            <v-btn
              color="secondary"
              href="https://qntm.org/files/absurdle/absurdle.html"
              target="_blank"
            >
              Try another game
            </v-btn>
          </div>
        </v-card-actions>
        <p align="center">
          Based on the game
          <a
            href="https://www.nytimes.com/games/wordle/index.html"
            target="_blank"
            >Wordle</a
          >
        </p>
      </v-card>
    </v-row>
  </v-container>
</template>
