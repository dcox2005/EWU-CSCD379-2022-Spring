<template>
  <v-container>
    <v-row justify="center">
      <!-- Back Button -->
      <v-col cols="1">
        <v-btn
          fab
          v-bind="attrs"
          color="primary"
          v-on="on"
          @click="$router.go(-1)"
        >
          <v-icon>mdi-arrow-left</v-icon>
        </v-btn>
      </v-col>

      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>How to Play</h1>
          </v-card-title>
        </v-card>
      </v-col>

      <v-col cols="6">
        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              A player has 6 tries to guess a 5 letter word
              <v-spacer />
              After a guess if the letter is  not in the right box but is still part of the word it'll be highlighted yellow
              <v-img src="/yellowGuess.JPG" />
              <v-spacer />
              <v-spacer />
              And if the letter is in the right box it'll be highlighted green
              <v-img src="/greenGuess.JPG" />
              <v-spacer />
              If the letters are not part of the word they'll show up gray
              <v-spacer />
              If the player guesses the word within 6 tries they win
              <v-img src="/won.JPG" />
            </v-card-text>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
