<script setup>
</script>

<template>
    <header>
        <input v-model="nameSearch" placeholder="movie search" />
        <div class="container">
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th> Release Date</th>
                        <th> Title</th>
                        <th> Overview</th>
                        <th> Popularity</th>
                        <th> Vote Count</th>
                        <th> Original Language</th>
                        <th> Genre</th>
                        <th> Poster URL</th>
                    </tr>
                </thead>
                <tr v-for="movie in movies">
                    <th> {{movie.releaseDate}}</th>
                    <th> {{movie.title}}</th>
                    <th> {{movie.overview}}</th>
                    <th> {{movie.popularity}}</th>
                    <th> {{movie.voteCount}}</th>
                    <th> {{movie.originalLanguage}}</th>
                    <th> {{movie.genre}}</th>
                    <th> {{movie.posterUrl}}</th>
                </tr>


            </table>


        </div>
    </header>

  <main>
  </main>
</template>

<script>
    const nameSearch = "";
    import axios from "axios";

    export default {
        name: "App",
        data() {
            return {
                movies: {},
            };
        },
        methods: {
            async GetMovies() {
                const { data } = await axios.get(
                    "https://localhost:7271/MoviesByName",
                    {
                        params: {
                            nameSearch: nameSearch
                        },
                    }
                );
                console.log(data);
                this.answer = data;
            },
        },
        beforeMount() {
            this.GetMovies();
        },
    };
</script>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
