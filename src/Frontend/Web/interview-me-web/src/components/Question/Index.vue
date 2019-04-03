<template>
    <div>
        <h1>Question</h1>
        <hr>
        <form class="col-lg-6">
            <h3>Add Question</h3>
            <div class="form-group">    
                <label for="title">Title</label>
                <input type="text" id="title" class="form-control" v-model="question.title">  
            </div>
            <div class="form-group"> 
                <label for="bodyText">Body</label>
                <textarea id="bodyText" class="form-control" cols="30" rows="10" v-model="question.bodyText"></textarea>
            </div>
            <button class="btn btn-primary" @click="addQuestion">Add New Question</button>
        </form>
        <hr>
        <div>
            <h3>Questions List</h3> <button class="btn btn-success" @click="fetchData">Get Data</button>
           
            <ul class="list-group">
                <li class="list-group-item" v-for="question in questions">
                    {{ question.title }}
                </li>
            </ul>
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
            },
            questions:[]
        }
    },
    methods: {
        fetchData() {
            this.$http.get('https://localhost:5001/api/questions')
                .then(response => {
                    return response.json();
                })
                .then(data => {
                    const resultArray=[];
                    for(let key in data) {
                        resultArray.push(data[key]);
                    }
                    this.questions=resultArray;
                });
        },
        addQuestion() {
            this.$http.post('https://localhost:5001/api/questions',this.question)
                .then(response => {
                   clearForm();
                   fetchData();
                }, error => {
                    
                });
        },
        clearForm() {
            this.question.title='';
            this.question.bodyText='';
        }
    }
}
</script>
