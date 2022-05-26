<template>
  <v-app style="background: #064A80">
  <v-container>
    <v-row justify="center">
      <v-col cols="8">
        <v-card color="transparent" flat>
          <v-card-title class="justify-center">
            <NotWordleLogo />
          </v-card-title>
          <v-card-title class="justify-center">
            <Birdle />
          </v-card-title>
          <v-card color="transparent" flat>
            <v-card-actions class="justify-center">
              <v-btn nuxt to="/game" color="#3A96B5" x-large width="200px">
                Play
              </v-btn>
              <v-btn nuxt to="/dailyGamme" color="#3A96B5" x-large width="200px">
                Play Daily Game
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
  </v-app>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class IndexPage extends Vue {}
</script>

<!-- <v-btn color="info" nuxt to="/leaderboard">
            Leader Board
          </v-btn> -->
