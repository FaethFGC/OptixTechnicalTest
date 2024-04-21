<template>
    <header>
        <input v-model="nameSearch" placeholder="movie search" />
        <input v-model="genres" placeholder="genre search" />
        <input v-model="page" placeholder="page" />
        <input v-model="pageSize" placeholder="page size" />
        <button @click="getMovies()">Search</button>
    </header>
    <hr />
    <div id="Movies">
        <div v-if="movies != null">
            <div class="overflow-auto">
                <table class="table table-striped">
                    <tr>
                        <th scope="col">Title</th>
                        <th scope="col">Release Date</th>
                        <th scope="col">Overview</th>
                        <th scope="col">Popularity </th>
                        <th scope="col">Vote Count</th>
                        <th scope="col">Original Language</th>
                        <th scope="col">Genres</th>
                    </tr>
                    <tr v-for="item in movies" v-bind:key="item.title">
                        <td><img :src="item.posterUrl" contain height="200px" width="150px" /></td>
                        <td scope="row"> {{ item.title }}</td>
                        <td> {{item.releaseDate}}</td>
                        <td> {{item.overview}}</td>
                        <td> {{item.popularity}}</td>
                        <td> {{item.voteCount}}</td>
                        <td> {{item.originalLanguage}}</td>
                        <td> {{item.genre}}</td>
                    </tr>
                </table>
            </div>
        </div>
        <div v-else-if="loading == true">
            <h1>LOADING</h1>
        </div>
        <div v-else>
            <p>API connection failed</p>
        </div>
    </div>
</template>

<script>
    import VueNumericInput from 'vue-numeric-input'
    import axios from "axios";
    export default {
        name: "Movies",
        components: {
            VueNumericInput,
        },
        data() {
            return {
                movies: {},
                loading: true,
                error: {},
                currentPage: 1,
                nameSearch: "",
                genres: "",
                page: "1",
                pageSize: "30",
            };
        },
        methods: {
            async getMovies() {
                try {
                    let url = "https://localhost:7271/MoviesByName?nameSearch=" + this.nameSearch;
                    if (this.genres != "") {
                        url += "&genre=" + this.genres;
                    }

                    if (this.page != "") {
                        url += "&page=" + this.page;
                    }

                    if (this.pageSize != "") {
                        url += "&pageSize=" + this.pageSize
                    }

                    console.log(url)
                    const response = await axios.get(
                        url,
                    );
                    console.log(response.data);
                    this.movies = response.data;
                    this.loading = false;
                } catch (error) {
                    this.loading = false;
                    this.error = error;
                    console.log(error);
                }
            },
        },
        async mounted() {
        },
    };
</script>