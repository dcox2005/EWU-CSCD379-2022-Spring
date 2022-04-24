<template>
  <div>
    <v-btn icon @click="toggleDialog">
      <v-icon> mdi-cog </v-icon>
    </v-btn>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title> Settings </v-card-title>

          <v-card-text>
            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Pick Theme
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="turnOnTheLights">
                    <v-list-item-title> Light Mode </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="turnOffTheLights">
                    <v-list-item-title> Dark Mode </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>

            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Pick A Color
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="purpleTheme">
                    <v-list-item-title> Purple </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="neonsTheme">
                    <v-list-item-title> Neons </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="crazyTheme">
                    <v-list-item-title> Crazy </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="normalTheme">
                    <v-list-item-title> Boring Normal </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="backwardsTheme">
                    <v-list-item-title> Backwards </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { colors } from 'vuetify/lib'
@Component({})
export default class SettingsDialog extends Vue {
  dialog = false
  toggleDialog() {
    this.dialog = !this.dialog
  }

  turnOnTheLights() {
    this.$vuetify.theme.dark = false
  }

  turnOffTheLights() {
    this.$vuetify.theme.dark = true
  }

  purpleTheme() {
    const purpleTheme = {
      primary: colors.deepPurple,
      accent: colors.purple.accent3,
      secondary: colors.purple,
      info: '#03A9F4',
      warning: colors.pink.accent1,
      error: colors.pink.accent3,
      success: colors.deepPurple.lighten4,
    }
    this.$vuetify.theme.themes.dark = purpleTheme
    this.$vuetify.theme.themes.light = purpleTheme
  }

  crazyTheme() {
    const crazyTheme = {
      primary: '#EA899A',
      accent: '#C2B078',
      secondary: '#E5BE01',
      info: '#31372B',
      warning: '#BDECB6',
      error: '#ED760E',
      success: '#317F43',
    }
    this.$vuetify.theme.themes.dark = crazyTheme
    this.$vuetify.theme.themes.light = crazyTheme
  }

  neonsTheme() {
    const neonsTheme = {
      primary: '#00FFFF',
      accent: '#DB3EB1',
      secondary: '#4D4DFF',
      info: '#FFAD00',
      warning: '#E0E722',
      error: '#D22730',
      success: '#44D62C',
    }
    this.$vuetify.theme.themes.dark = neonsTheme
    this.$vuetify.theme.themes.light = neonsTheme
  }

  normalTheme() {
    const normalTheme = {
      primary: colors.blue.darken2,
      accent: colors.grey.darken3,
      secondary: colors.amber.darken3,
      info: colors.teal.lighten1,
      warning: colors.amber.base,
      error: colors.deepOrange.accent4,
      success: colors.green.accent3,
    }
    this.$vuetify.theme.themes.dark = normalTheme
    this.$vuetify.theme.themes.light = normalTheme
  }

  backwardsTheme() {
    const backwardsTheme = {
      primary: colors.amber.darken3,
      accent: colors.teal.lighten1,
      secondary: colors.blue.darken2,
      info: colors.grey.darken3,
      warning: colors.green.accent3,
      error: colors.amber.base,
      success: colors.deepOrange.accent4,
    }
    this.$vuetify.theme.themes.dark = backwardsTheme
    this.$vuetify.theme.themes.light = backwardsTheme
  }
}
</script>
