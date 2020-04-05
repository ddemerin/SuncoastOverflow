import React, { Component } from 'react'
import { Route, Switch } from 'react-router'
import { Layout } from './components/Layout'
import { Home } from './pages/Home'
import AllQuestions from './pages/AllQuestions'
import NotFound from './pages/NotFound'
import AskQuestion from './pages/AskQuestion'
import ViewQuestion from './pages/ViewQuestion'
import Search from './pages/Search'
import './custom.scss'
import './ask-question.scss'
import './AllQuestions.scss'
import './home.scss'
import './AllQuestions.scss'
import './viewQuestion.scss'
export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <Layout>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route exact path="/allquestions" component={AllQuestions} />
          <Route exact path="/question" component={AskQuestion} />
          <Route exact path="/question/:id" component={ViewQuestion} />
          <Route exact path="/search" component={Search} />
          <Route exact path="*" component={NotFound} />
        </Switch>
      </Layout>
    )
  }
}
