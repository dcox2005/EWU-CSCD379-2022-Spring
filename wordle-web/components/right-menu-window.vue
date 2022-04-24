<template>
  <div>
    <v-btn icon @click.stop="rightDrawer = !rightDrawer">
      <v-icon> mdi-hamburger-plus </v-icon>
    </v-btn>
    <v-navigation-drawer v-model="rightDrawer" right fixed app>
      <v-list>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            Enigma Vocablulary
          </v-list-item-title>
          <v-list-item-subtitle> Navigation Menu </v-list-item-subtitle>
        </v-list-item-content>
        <v-list-item
          v-for="(item, i) in items"
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
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({})
export default class RightMenuWindow extends Vue {
  rightDrawer: boolean = false
  items = [
    { title: 'Home Page', icon: 'mdi-home', link: './' },
    { title: 'Game', icon: 'mdi-nintendo-game-boy', link: './game' },
    { title: 'About', icon: 'mdi-help-circle', link: './aboutPage' },
  ]

  toggleRightDrawer(): void {
    this.rightDrawer = !this.rightDrawer
  }
}
</script>
