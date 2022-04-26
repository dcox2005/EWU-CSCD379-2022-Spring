import { AvailableWords } from '~/scripts/AvailableWords'
import { WordsService } from '~/scripts/wordsService'

// import { AvailableWords } from '~/components/AvailableWords.vue';

describe('AvailableWord', () => {
  let word
  let words
  let allWords
  test('is an instance', () => {
    words = new AvailableWords()
    expect(words).toBeTruthy()
  })

  test('all words found', () => {
    word = '?????'
    words = new AvailableWords()
    allWords = words.validWords(word)
    expect(allWords.length).toBe(WordsService.getWords().length)
  })

  test('no words found', () => {
    words = new AvailableWords()
    expect(words.count).toBe(0)
    word = 'APPLE'
    allWords = words.validWords(word)
    expect(words.count).toBe(0)
    expect(allWords[0]).toBe('')
    expect(allWords[1]).toBeFalsy()
  })

  test('word A????', () => {
    words = new AvailableWords()
    word = 'A????'
    allWords = words.validWords(word)
    expect(allWords.length).toBeGreaterThan(0)
    expect(allWords.length).toBe(29)
    expect(words.count).toBe(29)
    expect(allWords.includes('ANGEL')).toBeTruthy()
    expect(allWords.includes('BATON')).toBeFalsy()
  })

  test('complicated ?A??H', () => {
    words = new AvailableWords()
    word = '?A??H'
    allWords = words.validWords(word)
    expect(allWords.length).toBeGreaterThan(0)
    expect(allWords.length).toBe(2)
    expect(words.count).toBe(2)
    expect(allWords.includes('BATCH')).toBeTruthy()
    expect(allWords.includes('GARTH')).toBeTruthy()
    expect(allWords.includes('BATON')).toBeFalsy()
  })

  test('find HUS?Y', () => {
    words = new AvailableWords()
    word = 'HUS?Y'
    allWords = words.validWords(word)
    expect(allWords.length).toBeGreaterThan(0)
    expect(allWords.length).toBe(1)
    expect(words.count).toBe(1)
    expect(allWords.includes('HUSKY')).toBeTruthy()
    expect(allWords.includes('GARTH')).toBeFalsy()
    expect(allWords.includes('BATON')).toBeFalsy()
  })
})
