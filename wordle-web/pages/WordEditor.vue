<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        Word Editor
      </v-card-title>
      <v-row>
        <v-col cols="12" sm="1"></v-col>
        <v-col cols="12" sm="1">
          <v-card-actions @click="firstPage">
            <v-icon>mdi-page-first</v-icon>
          </v-card-actions>
        </v-col>
        <v-col cols="12" sm="1">
          <v-card-actions @click="decrementPage">
            <v-icon>mdi-arrow-left-drop-circle</v-icon>
          </v-card-actions>
        </v-col>
        <v-col cols="12" sm="5"></v-col>
        <v-col cols="12" sm="1">
          <v-card-actions @click="incrementPage">
            <v-icon>mdi-arrow-right-drop-circle</v-icon>
          </v-card-actions>
        </v-col>
        <v-col cols="12" sm="1">
          <v-card-actions @click="lastPage">
            <v-icon>mdi-page-last</v-icon>
          </v-card-actions>
        </v-col>
      </v-row>
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
              <td style="text-align: center">{{printWordCommon(word.common)}}</td>
              <td style="text-align: center">
                <v-icon>mdi-trash-can-outline</v-icon>
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
    pageNumber: number = 5;
    searchParameter: String = "";
    words: any = [];

    mounted(){
        this.getWordList();
    }

    firstPage()
    {
      this.pageNumber = 1;
      this.getWordList();
    }

    decrementPage()
    {
      this.pageNumber--;
      if (this.pageNumber < 1)
      {
        this.pageNumber = 1;
      }
      this.getWordList();
    }
    
    incrementPage()
    {
      this.pageNumber++;
      if (this.pageNumber > 1000)
      {
        this.pageNumber = 1;
      }
      this.getWordList();
    }

    lastPage()
    {
        if (this.searchParameter === "")
        {
            this.$axios.post('/api/Word/GetLastPage', {
            page: this.pageNumber,
            pageSize: this.pageSize,
        })
        .then((result) => {
            this.words = result.data
        });
        }
        else
        {
            this.$axios.post('/api/Word/GetWordSearchLast', {
                searchParameter: this.searchParameter,
                page: this.pageNumber,
                pageSize: this.pageSize,
            })
            .then((response) => {
                this.words = response.data
            });
        }
    }

    getWordList()
    {
        if (this.searchParameter === "")
        {
            this.$axios.post('/api/Word/GetWordPage', {
            page: this.pageNumber,
            pageSize: this.pageSize,
        })
        .then((result) => {
            this.words = result.data
        });
        }
        else
        {
            this.$axios.post('/api/Word/GetWordSearchPage', {
                searchParameter: this.searchParameter,
                page: this.pageNumber,
                pageSize: this.pageSize,
            })
            .then((response) => {
                this.words = response.data
            });
        }
    }

    printWordCommon(commonWord: any)
    {
        if(commonWord)
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }
}
</script>
