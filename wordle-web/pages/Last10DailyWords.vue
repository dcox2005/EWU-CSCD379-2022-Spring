<template>
  <v-app style="background: #064a80">
    <v-container fluid justify-center>
      <v-row justify="center">
        <v-col cols="12" lg="6">
          <v-card>
            <v-card-title class="display-1 text-sm-display-3 justify-center">
              Last 10 Daily Words
            </v-card-title>
            <v-card-text>
              <v-simple-table>
                <thead>
                  <tr>
                    <th>Date</th>
                    <th style="text-align: center"># Plays</th>
                    <th style="text-align: center">Avg. Score</th>
                    <th style="text-align: center">Avg. Time (s)</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(dateWord, dateWordID) in words" :key="dateWordID">
                    <td>{{ dateWord.date.substring(0, 10) }}</td>
                    <td style="text-align: center">
                      {{ dateWord.numberOfPlays }}
                    </td>
                    <td style="text-align: center">
                      {{ dateWord.averageScore }}
                    </td>
                    <td style="text-align: center">
                      {{ dateWord.averageTime }}
                    </td>
                  </tr>
                </tbody>
              </v-simple-table>
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class Last10DailyWords extends Vue {
  words: any = []

  created() {
    this.GetLast10DailyWords()
  }

  GetLast10DailyWords() {
    this.$axios.get('/DateWord/GetLast10DailyWords').then((response) => {
      this.words = response.data
    })
  }
}
</script>
