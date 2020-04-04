import React from 'react'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCaretUp } from '@fortawesome/free-solid-svg-icons'
import { faCaretDown } from '@fortawesome/free-solid-svg-icons'

// apply base code for map all answers to answer component

const Answer = props => {
  const { response } = props

  return (
    <li>
      <section className="answer">
        <aside className="questionVoteSymbols">
          <section className="upVote">
            <button>
              <FontAwesomeIcon icon={faCaretUp} className="upVoteIcon" />
            </button>
          </section>
          <p className="voteCount">0</p>
          <section className="downVote">
            <button>
              <FontAwesomeIcon icon={faCaretDown} className="downVoteIcon" />
            </button>
          </section>
        </aside>
        <p className="response">
          {response}
          {/* The response to end all responses and forevermore tell you to suck it
          because you have no clue what you are doing. */}
        </p>
      </section>
      <section className="answerFooter">
        <section className="author">
          <p>Anonymous</p>
        </section>
        <section className="answerTime">
          {/* <p>answer.timeSubmitted</p> */}
        </section>
      </section>
    </li>
  )
}

export default Answer
