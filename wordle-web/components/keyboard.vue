<template>
  <v-container>
    <v-card class="mx-auto" width="900">
      <v-row v-for="(charRow, i) in chars" :key="i" no-gutters justify="center">
        <v-col v-for="char in charRow" :key="char" cols="1">
          <v-container class="text-center">
            <v-btn
              :elevation="15"
              :color="letterColor(char)"
              :disabled="wordleGame.gameOver"
              @click="setLetter(char)"
            >
              {{ char }}
            </v-btn>
          </v-container>
        </v-col>
      </v-row>
      <v-btn
        :disabled="wordleGame.gameOver"
        class="justify-start"
        @click="guessWord"
      >
        Guess
      </v-btn>
      <v-btn
        :disabled="wordleGame.gameOver"
        icon
        class="float-right"
        @click="removeLetter"
      >
        <v-icon>mdi-backspace</v-icon>
      </v-btn>
      <v-row>
        <available-words :wordleGame="wordleGame" />
      </v-row>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { Letter, LetterStatus } from '~/scripts/letter'
import { WordleGame } from '~/scripts/wordleGame'

@Component
export default class KeyBoard extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  chars = [
    ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
    ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
    ['Z', 'X', 'C', 'V', 'B', 'N', 'M', '?'],
  ]

  setLetter(char: string) {
    this.wordleGame.currentWord.addLetter(char)
  }

  removeLetter() {
    this.wordleGame.currentWord.removeLetter()
  }

  guessWord() {
    if (
      this.wordleGame.currentWord.length ===
      this.wordleGame.currentWord.maxLetters
    ) {
      this.wordleGame.submitWord()
    }
  }

  letterColor(char: string): string {
    if (this.wordleGame.correctChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.Correct)
    }
    if (this.wordleGame.wrongPlaceChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.WrongPlace)
    }
    if (this.wordleGame.wrongChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.Wrong)
    }

    return Letter.getColorCode(LetterStatus.Unknown)
  }
}
</script>
