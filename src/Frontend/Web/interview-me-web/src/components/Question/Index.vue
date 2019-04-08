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
                <label for="body">Body</label>
                <textarea id="body" class="form-control" cols="30" rows="5" v-model="question.body"></textarea>
            </div>
            <div class="form-group">    
                <label for="tags">Tags</label>
                <input type="text" id="tags" class="form-control" v-model="question.tags">  
            </div>
            <button class="btn btn-primary" @click="addQuestion">Add New Question</button>
        </form>
        <hr>
        <div>
            <h3>Questions List</h3> <button class="btn btn-success" @click="getQuestions('')">Get Questions</button>
           
            <ul class="list-group">
                <li class="list-group-item" v-for="question in questions">
                   {{ question.title }}
                   
                   <span v-if="question.tags">
                       <a @click.prevent="getQuestions(tag)" href="#" v-for="tag in question.tags.split(',')"> #{{ tag }}</a> 
                   </span>
                 
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
                body:'',
                tags:''
            },
            questions:[]
        }
    },
    methods: {
        getQuestions(tag) {
            this.$http.get('https://localhost:5001/api/questions/'+tag)
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
                   getQuestions();
                });
        },
        clearForm() {
            this.question.title='';
            this.question.body='';
            this.question.tags='';
        }
    }
}
</script>
