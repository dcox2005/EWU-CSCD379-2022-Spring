import { WordsService } from '~/scripts/wordsService'

export class AvailableWords {
  words: string[] = []
  count: number = 0

  validWords(word: string): string[] 
  {
    this.words = []
    if (!word.includes('?')) 
    {
      this.words.push('')
      this.count = 0
      return this.words
    }

    let expression: string = '^[A-Z]{0,5}'
    for (let i = 0; i < 5; i++) 
    {
      if (word.charAt(i) === '?') 
      {
        expression += '[A-Z]'
      } 
      else 
      {
        expression += word.charAt(i)
      }
    }

    const regex: RegExp = new RegExp(expression)
    let wordList: string[] = WordsService.getWords()
    for (let i = 0; i < wordList.length; i++) {
      if (regex.test(wordList[i])) {
        this.words.push(wordList[i])
      }
    }

    wordList = []

    this.count = this.words.length
    return this.words
  }
}
