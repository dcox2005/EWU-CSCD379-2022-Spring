<template>
  <div class>
    <v-container @click="toggleDialog">
      <v-icon>mdi-account-circle</v-icon>
    </v-container>
    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title>User Login</v-card-title>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({})
export default class UserLogin extends Vue {
  dialog = false

  toggleDialog() {
    this.dialog = !this.dialog
  }
}
</script>