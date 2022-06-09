<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        Word Editor
      </v-card-title>
      <v-card-text>
        <v-simple-table>
          <thead>
            <tr>
              <th style="text-align: center">Word</th>
              <th style="text-align: center">Common</th>
              <th style="text-align: center"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(word, wordId) in words" :key="wordId">
              <td>{{ word.value }}</td>
              <td style="text-align: center">{{ words.common }}</td>
              <td style="text-align: center">
              </td>
            </tr>
          </tbody>
        </v-simple-table>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'


@Component({})
export default class WordEditor extends Vue {
    pageSize: number = 20;
    pageNumber: number = 1;
    searchParameter: String = "";
    words: any = [];

    mounted(){
        this.getWordList();
    }

    getWordList()
    {
        if (this.searchParameter === "")
        {
            this.$axios.post('/api/Word/GetPageWordList', {
            page: this.pageNumber,
            pageSize: this.pageSize,
        })
        .then((response) => {
console.log(`post finished. here is the response`);
console.log(`${response.data}`);
            this.words = response.data
        })
        .then( () =>
        {

            console.log(`${this.words}`)
        });
        }
        else
        {
            this.$axios.post('/api/Word/GetWordSearchPageList', {
                searchParameter: this.searchParameter,
                page: this.pageNumber,
                pageSize: this.pageSize,
            })
            .then((response) => {
    console.log(`post finished. here is the response`);
    console.log(`${response.data}`);
                this.words = response.data
            })
            .then( () =>
            {
    
                console.log(`${this.words}`)
            });
        }

    }
}
</script>
