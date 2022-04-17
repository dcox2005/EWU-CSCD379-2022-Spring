<template>
    <v-container fill-height justify-center>
        <v-btn
            :disabled="wordleGame.gameOver"
            @click="[validWords(), showCountButton()]"
        >
            Available Words
        </v-btn>
        <v-dialog
            v-model="dialog"
            width="500"
        >
            <template v-slot:activator="{ on, attrs }">
                <v-btn
                    v-bind="attrs"
                    v-on="on"
                    v-show="countButton"
                >
                    {{availableWordCount}}
                </v-btn>
            </template>

            <v-card>
                <v-card-title class="text-h5 light-blue darken-1">
                    Available Words
                </v-card-title>
                <v-divider></v-divider>

                <v-card-actions>
                    <v-container>
                        <v-row v-for="i in rowLoopCount()" :key="i" no-gutters justify="center">
                            <v-col v-for="n in 3" :key="n" md="4">
                                <v-spacer></v-spacer>
                                <v-btn
                                    color="primary"
                                    text
                                    @click="[dialog = false, addWord(availableWords[(i - 1) * 3 + (n - 1)])]"
                                >
                                    {{availableWords[(i - 1) * 3 + (n - 1)]}}
                                </v-btn>
            
                            </v-col>
                        </v-row>
                    </v-container>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordsService } from '~/scripts/wordsService';
import { WordleGame } from '~/scripts/wordleGame'


@Component({ components: {} })
export default class AvailableWords extends Vue 
{
    @Prop({ required: true })
    wordleGame!: WordleGame;

    availableWords: string[] = [];
    availableWordCount: number = 0;
    countButton: boolean = false;
    dialog: boolean = false;

    validWords(): string[]
    {
        const word: string = this.wordleGame.currentWord.text;
        console.log(`word: ${word}`);
        this.availableWords = [];
        if(!word.includes("?"))
        {
            this.availableWords.push("");
            this.availableWordCount = 0;
            return this.availableWords;
        }

        let expression: string = "^[a-z]{0,5}";
        for(let i = 0; i < 5; i++)
        {
            if(word.charAt(i) === '?')
            {
                expression += "[a-z]";
            }
            else
            {
                expression += word.charAt(i);
            }
        }

        let regex: RegExp = new RegExp(expression);
        let wordList: string[] = WordsService.getWords();
        for(let i = 0; i < wordList.length; i++)
        {
            if(regex.test(wordList[i]))
            {
                this.availableWords.push(wordList[i]);
            }
        }

        wordList = [];

        this.availableWordCount = this.availableWords.length;
        return this.availableWords;
    }

    showCountButton()
    {
        this.countButton = true;
    }

    rowLoopCount()
    {
        return Math.ceil(this.availableWordCount / 3);
    }

    addWord(word: string)
    {
        for(let i = 0; i < 5; i++)
        {
           this.wordleGame.currentWord.removeLetter();
        }

        for(let i = 0; i < 5; i++)
        {
           this.wordleGame.currentWord.addLetter(word.charAt(i));
        }
    }
}
</script>
