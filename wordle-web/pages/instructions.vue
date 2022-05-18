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

      <!-- Game Info Card(s) -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>How to Play</h1>
          </v-card-title>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
