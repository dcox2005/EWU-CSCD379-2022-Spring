import { WordsService } from '~/scripts/wordsService';
import { WordleGame } from '~/scripts/wordleGame'


export class AvailableWords 
{
    availableWords: string[] = [];
    availableWordCount: number = 0;
    countButton: boolean = false;

    validWords(word: string): string[]
    {
        // const word: string = this.wordleGame.currentWord.text;
        // console.log(`word: ${word}`);
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
}