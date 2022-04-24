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
    word = 'apple'
    allWords = words.validWords(word)
    expect(words.count).toBe(0)
    expect(allWords[0]).toBe('')
    expect(allWords[1]).toBeFalsy()
  })

  test('word a????', () => {
    words = new AvailableWords()
    word = 'a????'
    allWords = words.validWords(word)
    expect(allWords.length).toBeGreaterThan(0)
    expect(allWords.length).toBe(29)
    expect(words.count).toBe(29)
    expect(allWords.includes('angel')).toBeTruthy()
    expect(allWords.includes('baton')).toBeFalsy()
  })

  test('complicated ?a??h', () => {
    words = new AvailableWords()
    word = '?a??h'
    allWords = words.validWords(word)
    expect(allWords.length).toBeGreaterThan(0)
    expect(allWords.length).toBe(2)
    expect(words.count).toBe(2)
    expect(allWords.includes('batch')).toBeTruthy()
    expect(allWords.includes('garth')).toBeTruthy()
    expect(allWords.includes('baton')).toBeFalsy()
  })

  test('find hus?y', () => {
    words = new AvailableWords()
    word = 'hus?y'
    allWords = words.validWords(word)
    expect(allWords.length).toBeGreaterThan(0)
    expect(allWords.length).toBe(1)
    expect(words.count).toBe(1)
    expect(allWords.includes('husky')).toBeTruthy()
    expect(allWords.includes('garth')).toBeFalsy()
    expect(allWords.includes('baton')).toBeFalsy()
  })
})
