<template>
    <div>
        <h1>Question</h1>
        <hr>
        <div>
            <h3>Add Question</h3>
            <input type="text" v-model="question.title">
            <textarea cols="30" rows="10" v-model="question.bodyText"></textarea>
            <button @click="addQuestion">Add New Question</button>
        </div>
        <hr>
        <div>
            <h3>Questions List</h3>
            <ul><li></li></ul>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            question: {
                title:'',
                bodyText:''
            }
        }
    },
    methods: {
        addQuestion() {
            this.$http.post('https://localhost:5001/api/questions',this.question);
                // .then(response => {
                //     alert('Added!');
                // }, error => {
                //     alert(error);
                // });
        }
    }
}
</script>
