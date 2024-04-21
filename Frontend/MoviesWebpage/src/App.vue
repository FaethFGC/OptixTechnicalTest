<template>
    <header>
        <input v-model="nameSearch" placeholder="movie search" />
    </header>
    <hr />
    <div id="Movies">
        <div v-if="movies != null">
            <div class="overflow-auto">
                <b-pagination v-model="currentPage"
                              :total-rows="rows"
                              :per-page="perPage"></b-pagination>
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
    import axios from "axios";
    const nameSearch = "";
    export default {
        name: "Movies",
        components: {},
        data() {
            return {
                movies: {},
                loading: true,
                error: {},
            };
        },
        methods: {
        },
        async mounted() {
            try {
                let url = "https://localhost:7271/MoviesByName?nameSearch=" + nameSearch;
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
    };
</script>