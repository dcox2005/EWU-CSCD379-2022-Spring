<template>
  <v-app>
    <v-app-bar fixed app>
      <router-link to="/" class="text-h4 font-weight-black no-decoration">
        <v-icon> mdi-chevron-double-up </v-icon>
        Enigma Vocabulary
        <v-icon> mdi-flask </v-icon>
      </router-link>
      <v-spacer />
      <settings-dialog />
      <v-btn icon @click.stop="rightDrawer = !rightDrawer">
        <v-icon> mdi-hamburger-plus </v-icon>
      </v-btn>
    </v-app-bar>
    <v-navigation-drawer v-model="rightDrawer" right fixed app>
      <v-list>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            Enigma Vocablulary
          </v-list-item-title>
          <v-list-item-subtitle> Navigation Menu </v-list-item-subtitle>
        </v-list-item-content>
        <v-list-item
          v-for="(item, i) in rightItems"
          :key="i"
          :to="item.link"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import SettingsDialog from '~/components/settings-dialog.vue'

@Component({ components: { SettingsDialog } })
export default class DefaultLayout extends Vue {
  rightDrawer: boolean = false
  rightItems = [
    { title: 'Home Page', icon: 'mdi-home', link: './' },
    { title: 'Game', icon: 'mdi-nintendo-game-boy', link: './game' },
    { title: 'About', icon: 'mdi-help-circle', link: './aboutPage' },
  ]
}
</script>

<style>
.no-decoration {
  text-decoration: none;
}
</style>
