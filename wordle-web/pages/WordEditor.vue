<template>
  <v-container fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        Word Editor
      </v-card-title>
      <v-alert v-if="newWordSet" width="80%" :type="newWordResultType">
          {{ newWordResultText }}
        </v-alert>
        <v-alert v-if="wordToDeleteSet" width="80%" :type="wordToDeleteResultType">
          {{ wordToDeleteResultText }}
        </v-alert>
      <v-form v-if="authorizedToAddDelete" method="post" @submit.prevent="addWord">
              <v-container>
                <v-row>
                  <v-col 
                    cols="12" md="6"
                  >
                    <v-text-field
                      v-model="newWord"
                      label="New Word"
                      required
                    ></v-text-field>
                  </v-col>
                <v-col cols="12" md="6">
                  <v-btn type="submit">Add Word</v-btn>
                </v-col>
              </v-row>
              </v-container>
            </v-form>
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
        <v-text-field
                  @keyup="getWordList()"
                  v-model="searchParameter"
                  type="text"
                  placeholder="Search for Word"
                ></v-text-field>
        <v-simple-table>
          <thead>
            <tr>
              <th style="text-align: center">Word</th>
              <th style="text-align: center">Common</th>
              <th v-if="authorizedToAddDelete" style="text-align: center"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(word, wordId) in words" :key="wordId">
              <td style="text-align: center">{{ word.value }}</td>
              <td style="text-align: center">{{printWordCommon(word.common)}}</td>
              <td v-if="authorizedToAddDelete" style="text-align: center">
                <v-card-actions @click="deleteWord(word.value)">
                  <v-icon>mdi-trash-can-outline</v-icon>
                </v-card-actions>
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
import { JWT } from '~/scripts/jwt';


@Component({})
export default class WordEditor extends Vue {
    pageSize: number = 20;
    pageNumber: number = 1;
    searchParameter: String = "";
    words: any = [];
    newWord: String = "";
    newWordSet: boolean = false;
    newWordResultType: String = `Success`;
    newWordResultText: String = "";
    wordToDeleteSet: boolean = false;
    wordToDeleteResultType: String = `Success`;
    wordToDeleteResultText: String = "";
    authorizedToAddDelete: boolean = false;

    mounted(){
      this.getWordList();
      if(JWT.tokenData.roles.includes("MasterOfTheUniverse") && JWT.age >= 21)
      {
        this.authorizedToAddDelete = true;
      }
      setInterval(() => {
        if(JWT.tokenData.roles.includes("MasterOfTheUniverse") && JWT.age >= 21)
        {
          this.authorizedToAddDelete = true;
        }
        else
        {
          this.authorizedToAddDelete = false;
        }
      }, 5000)
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

    addWord()
    {
      if (this.newWord.length < 5 || this.newWord.length > 5)
      {
        this.newWordResultType = 'warning';
        this.newWordSet = true;
        this.newWordResultText = 'Word must be exactly 5 letters!'
      }
      else
      {
        let addResults = false;
        this.$axios.post('/api/Word/AddWord', {
            word: this.newWord,
        })
        .then((result) => {
            addResults = result.data
        })
        .then(() => {
          if (addResults)
          {
            this.newWordResultType = 'success';
            this.newWordResultText = 'Thy will be done!'
            
            this.$forceUpdate();
          }
          else
          {
            this.newWordResultType = 'warning';
            this.newWordResultText = 'Word not added. Error occurred.'
          }
          this.newWordSet = true;
          this.getWordList();
        })
        .catch(() => {
          this.newWordResultType = 'warning';
          this.newWordResultText = 'Error occurred. Word not added.'
          this.newWordSet = true;
          this.getWordList();
        });
      }
      setTimeout(() => {this.newWordSet = false}, 5000)
    }

    deleteWord(wordToDelete: String)
    {
      if (wordToDelete.length < 5 || wordToDelete.length > 5)
      {
        this.wordToDeleteResultType = 'warning';
        this.wordToDeleteSet = true;
        this.wordToDeleteResultText = 'Word must be exactly 5 letters!'
      }
      else
      {
        let deleteResults = false;
        this.$axios.post('/api/Word/DeleteWord', {
            word: wordToDelete,
        })
        .then((result) => {
            deleteResults = result.data
        })
        .then(() => {
          if (deleteResults)
          {
            this.wordToDeleteResultType = 'success';
            this.wordToDeleteResultText = 'Thy will be done!'
            this.$forceUpdate();
          }
          else
          {
            this.wordToDeleteResultType = 'warning';
            this.wordToDeleteResultText = 'Word not deleted. Error occurred.'
          }
          this.wordToDeleteSet = true;
          this.getWordList();
        })
        .catch(() => {
          this.wordToDeleteResultType = 'warning';
          this.wordToDeleteResultText = 'Error occurred. Word not deleted.'
          this.wordToDeleteSet = true;
          this.getWordList();
        });
      }
      setTimeout(() => {this.wordToDeleteSet = false}, 5000)
    }
}
</script>
