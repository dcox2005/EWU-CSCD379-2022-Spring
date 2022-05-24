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

      <v-col cols="10">
        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              1. A player has 6 tries to guess a 5 letter word
              <v-spacer />
              2. Words can have multiples of the same letter, ex: HELLO
              <v-spacer />
              3. After a guess if the letter is not in the right box but is still part of the word it'll be highlighted yellow
              <v-img src="/yellow.JPG" />
              <v-spacer />
            </v-card-text>
          </div>
        </v-card>

        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              4. And if the letter is in the right box it'll be highlighted green
              <v-img src="/green.JPG" />
              <v-spacer />
              5. If the letters are not part of the word they'll show up gray
              <v-spacer />
            </v-card-text>
          </div>
        </v-card>

        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              6. If the player guesses the word within 6 tries they win
              <v-img src="/won.PNG" />
            </v-card-text>
          </div>
        </v-card>

        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              7. Player also has the option of using the ? key to narrow down the list of options
              <v-img src="/qMark.PNG" />
            </v-card-text>
          </div>
        </v-card>

        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              Clicking on the list of available words shows the player a list of words that can be used
              <v-img src="/qMark1.PNG" width="1000"/>
            </v-card-text>
          </div>
        </v-card>

        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              8. Another way of using the ? key
              <v-img src="/qMark2.PNG" width="1000"/>
            </v-card-text>
          </div>
        </v-card>

      </v-col>

    </v-row>
  </v-container>
</template>
